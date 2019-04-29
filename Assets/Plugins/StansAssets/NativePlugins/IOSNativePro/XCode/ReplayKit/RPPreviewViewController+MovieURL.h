//
//  RPPreviewViewController+MovieURL.h
//  hschefu-ios-staff
//
//  Created by qiu on 2018/8/28.
//  Copyright © 2018年 CodeTeam. All rights reserved.
//

#import <ReplayKit/ReplayKit.h>

/// save callback block
typedef void(^CallbackSaveVideo)(NSError* error);

@interface RPPreviewViewController (MovieURL)

@property (nonatomic, strong) NSURL *movieURL;

@property (nonatomic, copy) CallbackSaveVideo callbackSaveVideo;

/**
 save video
 */
- (void)saveVideo:(CallbackSaveVideo)callbackSaveVideo;

@end
