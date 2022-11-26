using System;
using Microsoft.AspNetCore.Components;

namespace StateManagement.State
{
    public class BaseSubscriber : ComponentBase, IDisposable
    {
        [CascadingParameter]
        public StateStore Store { get; set; }

        protected override void OnInitialized()
        {
            Store.ApplicationStateChangedHandler += ReRender;
            base.OnInitialized();
        }

        private void ReRender(object sender, ApplicationStateChanged e) => StateHasChanged();

        public void Dispose() => Store.ApplicationStateChangedHandler -= ReRender;
    }
}
