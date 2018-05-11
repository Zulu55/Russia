namespace RussiaX.iOS
{
    using Foundation;
    using Syncfusion.SfBusyIndicator.XForms.iOS;
    using UIKit;

    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            new SfBusyIndicatorRenderer();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
