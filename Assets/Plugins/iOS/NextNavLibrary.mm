#import <Foundation/Foundation.h>

@interface NextNavLibrary: NSObject
{
    NSDate *creationDate;
}
@end

@implementation NextNavLibrary

static NextNavLibrary *_sharedInstance;

+(NextNavLibrary*) sharedInstance
{
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        NSLog(@"Creating NextNavLibrary shared instance");
        _sharedInstance = [[NextNavLibrary alloc] init];
    });

    return _sharedInstance;
}

-(id)init
{
    self = [super init];
    if(self)
        [self initHelper];

    return self;
}

-(void)initHelper{
    NSLog(@"InitHelper called");
    creationDate = [NSDate date];
}

-(double)getElapsedTime
{
    return [[NSDate date] timeIntervalSinceDate:creationDate];
}


@end


extern "C"
{
    double IOSgetElapsedTime()
    {
        return [[NextNavLibrary sharedInstance] getElapsedTime];
    }
}