using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DatenbankUWPMVVM.Controls
{
    public partial class NavControl : UserControl
    {
        public static DependencyProperty ForwardButtonProperty =
           DependencyProperty.Register("ForwardButtonCommand", typeof(ICommand), typeof(NavControl), new PropertyMetadata(null));

        public static DependencyProperty BackwardButtonProperty =
          DependencyProperty.Register("BackwardButtonCommand", typeof(ICommand), typeof(NavControl), new PropertyMetadata(null));

        public static DependencyProperty TopButtonProperty =
          DependencyProperty.Register("TopButtonCommand", typeof(ICommand), typeof(NavControl), new PropertyMetadata(null));

        public static DependencyProperty BottomButtonProperty =
          DependencyProperty.Register("BottomButtonCommand", typeof(ICommand), typeof(NavControl), new PropertyMetadata(null));

        public static DependencyProperty ComboboxItemsProperty =
        DependencyProperty.Register("ComboBoxItems", typeof(ObservableCollection<int>), typeof(NavControl), new PropertyMetadata(null));

        public static DependencyProperty ComboboxIndexProperty =
        DependencyProperty.Register("ComboBoxIndex", typeof(int), typeof(NavControl), new PropertyMetadata(null));


        public ICommand ForwardButtonCommand
        {
            get { return (ICommand)GetValue(ForwardButtonProperty); }
            set { SetValue(ForwardButtonProperty, value); }
        }

        public ICommand BackwardButtonCommand
        {
            get { return (ICommand)GetValue(BackwardButtonProperty); }
            set { SetValue(BackwardButtonProperty, value); }
        }

        public ICommand TopButtonCommand
        {
            get { return (ICommand)GetValue(TopButtonProperty); }
            set { SetValue(TopButtonProperty, value); }
        }

        public ICommand BottomButtonCommand
        {
            get { return (ICommand)GetValue(BottomButtonProperty); }
            set { SetValue(BottomButtonProperty, value); }
        }


        public ObservableCollection<int> ComboBoxItems
        {
            get { return (ObservableCollection<int>)GetValue(ComboboxItemsProperty); }
            set { SetValue(ComboboxItemsProperty, value); }
        }

        public int ComboBoxIndex
        {
            get { return (int)GetValue(ComboboxIndexProperty); }
            set { SetValue(ComboboxIndexProperty, value); }
        }
    }
}
