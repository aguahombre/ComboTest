using ReactiveUI;
using System.Collections.Generic;
using System.Reactive.Disposables;

namespace ComboTest
{
    public class MainWindowViewModel : ReactiveObject, IActivatableViewModel
    {
        private IList<string> items = new List<string>();
        private string? selectedItem;

        public MainWindowViewModel()
        {
            SelectedItem = "hello";

            this.WhenActivated(disposables =>
            {
                Items = new List<string>() { "goodbye", "hello" };
                disposables.Add(Disposable.Empty);
            });
        }

        public IList<string> Items { get => items; set => this.RaiseAndSetIfChanged(ref items, value); }
        public string? SelectedItem { get => selectedItem; set => this.RaiseAndSetIfChanged(ref selectedItem, value); }

        public ViewModelActivator Activator { get; } = new();
    }
}