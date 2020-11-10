
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestApp.Prism.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestAppMasterDetailPage : MasterDetailPage
    {
        public RestAppMasterDetailPage()
        {
            InitializeComponent();
        }
    }
}