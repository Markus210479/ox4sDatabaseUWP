using DatenbankUWPMVVM.ViewModels;
using Google.Protobuf.WellKnownTypes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Die Elementvorlage "Benutzersteuerelement" wird unter https://go.microsoft.com/fwlink/?LinkId=234236 dokumentiert.

namespace DatenbankUWPMVVM.Controls
{
    public sealed partial class NavControl : UserControl
    {
        public static object viewModelObject;

        public event SelectionChangedEventHandler SelectionChanged;

        public static DependencyProperty ForwardButtonProperty =
         DependencyProperty.Register("ForwardButtonCommand", typeof(ICommand), typeof(NavControl), new PropertyMetadata(null));

        public static DependencyProperty BackwardButtonProperty =
          DependencyProperty.Register("BackwardButtonCommand", typeof(ICommand), typeof(NavControl), new PropertyMetadata(null));

        public static DependencyProperty TopButtonProperty =
          DependencyProperty.Register("TopButtonCommand", typeof(ICommand), typeof(NavControl), new PropertyMetadata(null));

        public static DependencyProperty BottomButtonProperty =
          DependencyProperty.Register("BottomButtonCommand", typeof(ICommand), typeof(NavControl), new PropertyMetadata(null));

        //public static DependencyProperty SelectedIndexChangedProperty =
        // DependencyProperty.Register("SelectedIndexChanged", typeof(int), typeof(NavControl), new PropertyMetadata(null, new PropertyChangedCallback(OnSelectedIndexChanged)));


        public static DependencyProperty ComboboxItemsProperty =
        DependencyProperty.Register("ComboBoxItems", typeof(ObservableCollection<int>), typeof(NavControl), new PropertyMetadata(null));

        public static DependencyProperty ComboboxIndexProperty =
        DependencyProperty.Register("ComboBoxIndex", typeof(int), typeof(NavControl), new PropertyMetadata(null, new PropertyChangedCallback(OnSelectedIndexChanged)));

        

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

        //public ICommand SelectionChangedCmd
        //{
        //    get { return (ICommand)GetValue(SelectionChangedProperty); }
        //    set { SetValue(SelectionChangedProperty, value); }
        //}

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

        private static void OnSelectedIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = d as NavControl;
            picker.ComboBoxIndex = (int)e.NewValue;

            if(viewModelObject is ServicesViewModel)
            {
                ServicesViewModel.SelectionChangeData((int)e.NewValue);
            }
            if (viewModelObject is BauteileViewModel)
            {
                BauteileViewModel.SelectionChangeData((int)e.NewValue);
            }
            if (viewModelObject is BaugruppenViewModel)
            {
                BaugruppenViewModel.SelectionChangeData((int)e.NewValue);
            }
        }

        public NavControl()
        {
            this.InitializeComponent();
            DataContext= this;
        }

    }


}

