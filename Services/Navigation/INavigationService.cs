using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinNavy.ViewModels;

namespace XamarinNavy.Services.Navigation
{
    /// <summary>
    /// Defines the type of page and animation to perform on push/pop
    /// </summary>
    public class ViewTransitionArgs
    {
        public ViewTransitionArgs(bool isModal = false, bool isAnimated = true)
        {
            IsModal = isModal;
            IsAnimated = isAnimated;
        }

        public bool IsAnimated { get; set; }

        public bool IsModal { get; set; }
    }

    /// <summary>
    ///  Interface providing viewmodel-first navigation implemented in the NavigationService
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Reference to the previous page in the navigation stack
        /// </summary>
        BaseViewModel PreviousPageViewModel { get; }


        /// <summary>
        /// OnStart of the app - performs navigation to the first page to be shown
        /// </summary>
        /// <returns></returns>
        Page InitializeAsync(Page page);


        /// <summary>
        /// OnStart of the app - to be called for a masterdetailpage navigation instead of the normal navigation
        /// </summary>
        /// <param name="Master"> Masterpage - represents the list of menuitems </param>
        /// <param name="Detail"> Detailpage - represents the first page to display in the navigation area </param>
        /// <returns></returns>
        Page InitializeDrawerAsync(ContentPage Master, ContentPage Detail);


        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page"></param>
        /// <param name="args"></param>
        /// <param name="transArgs"> transition args (modal/animation) </param>
        /// <returns></returns>
        Task PushView(Page page, ViewTransitionArgs transArgs = null, object args = null);


      
        /// <summary>
        /// Removes current page from the stack
        /// </summary>
        /// <param name="args"> allows to specify if the page is modal </param>
        /// <returns></returns>
        void PopView(ViewTransitionArgs args);

        /// <summary>
        /// Pops the last page - not the current one - from the navigation stack
        /// </summary>
        /// <returns></returns>
        Task RemoveLastFromBackStackAsync();


        /// <summary>
        /// Clears the navigation stack. All the pages will be removed.
        /// </summary>
        /// <returns></returns>
        Task RemoveBackStackAsync();
    }
}
