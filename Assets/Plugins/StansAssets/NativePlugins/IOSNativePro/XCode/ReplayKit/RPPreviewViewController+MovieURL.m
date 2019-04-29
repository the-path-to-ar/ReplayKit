//
//  RPPreviewViewController+MovieURL.m
//  hschefu-ios-staff
//
//  Created by qiu on 2018/8/28.
//  Copyright © 2018年 CodeTeam. All rights reserved.
//

#import "RPPreviewViewController+MovieURL.h"


@implementation RPPreviewViewController (MovieURL)

@dynamic movieURL;

@dynamic callbackSaveVideo;

- (void)saveVideo:(CallbackSaveVideo)callbackSaveVideo
{
    dispatch_async(dispatch_get_main_queue(), ^{
        BOOL isResponds = [self respondsToSelector:@selector(movieURL)];
        if (isResponds == NO) {
            if (callbackSaveVideo) {
                callbackSaveVideo([NSError errorWithDomain:@"Can not found the property 'movieURL'" code:1 userInfo:nil]);
            }
            return;
        }
        NSURL *videoURL = [self.movieURL copy];
        if (videoURL == nil) {
            if (callbackSaveVideo) {
                callbackSaveVideo([NSError errorWithDomain:@"Can not get the videoURL" code:2 userInfo:nil]);
            }
            return;
        }
        NSLog(@"Current video path : %@", videoURL.path);
        if (UIVideoAtPathIsCompatibleWithSavedPhotosAlbum(videoURL.path) == NO) {
            if (callbackSaveVideo) {
                callbackSaveVideo([NSError errorWithDomain:@"Current video is not supported to save photos album" code:3 userInfo:nil]);
            }
            return;
        }
        UISaveVideoAtPathToSavedPhotosAlbum(videoURL.path, self, @selector(savedPhotoImage:didFinishSavingWithError:contextInfo:), (__bridge void*)callbackSaveVideo);
    });
}

- (void)savedPhotoImage:(UIImage*)image didFinishSavingWithError: (NSError *)error contextInfo: (void *)contextInfo {
    if (error != nil) {
        if (contextInfo != nil) {
            CallbackSaveVideo callback = (__bridge CallbackSaveVideo)contextInfo;
            callback([NSError errorWithDomain:error.description code:4 userInfo:nil]);
        }
        return;
    }
    NSLog(@"Save video successfully！！！");
    if (contextInfo != nil) {
        CallbackSaveVideo callback = (__bridge CallbackSaveVideo)contextInfo;
        callback(nil);
    }
}

@end
