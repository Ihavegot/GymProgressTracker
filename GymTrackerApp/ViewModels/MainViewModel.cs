using System.Collections.ObjectModel;
using System.Windows.Input;
using DynamicInputsApp.Models;

namespace DynamicInputsApp.ViewModels;

public class MainViewModel
{
    public ObservableCollection<InputItem> Items { get; } = new();

    public ICommand AddItemCommand { get; }
    public ICommand RemoveItemCommand { get; }

    public MainViewModel()
    {
        AddItemCommand = new Command(AddItem);
        RemoveItemCommand = new Command<InputItem>(RemoveItem);
    }

    void AddItem()
    {
        Items.Add(new InputItem());
    }

    void RemoveItem(InputItem item)
    {
        if (Items.Contains(item))
            Items.Remove(item);
    }
}
