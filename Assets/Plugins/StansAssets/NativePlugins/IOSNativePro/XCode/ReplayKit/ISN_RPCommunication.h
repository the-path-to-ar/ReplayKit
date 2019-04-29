
#import <ReplayKit/ReplayKit.h>
#import "ISN_Foundation.h"



@interface ISN_RPStopResult : SA_Result
@property (nonatomic)  bool m_hasPreviewController;
@end


@interface ISN_PRPreivewResult : SA_Result
@property (nonatomic)  NSArray <NSString *> *m_activityTypes;
-(id) initWithActivityTypes:(NSArray <NSString *>*) activityTypes;
@end

