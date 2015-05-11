using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TenantsManager.Model;

namespace TenantsManager
{
    /// <summary>
    /// Interaction logic for TenantsEditor.xaml
    /// </summary>
    public partial class TenantsEditor : UserControl
    {
        public TenantsEditor()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TenantProperty = DependencyProperty.Register(
            "Tenant", 
            typeof (Tenant), 
            typeof (TenantsEditor), 
            new PropertyMetadata(default(Tenant), OnTenantChanged));

        private static void OnTenantChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var oldTenant = dependencyPropertyChangedEventArgs.OldValue as Tenant;
            var newTenant = dependencyPropertyChangedEventArgs.NewValue as Tenant;

            string oldName = oldTenant == null
                ? "NULL"
                : oldTenant.Name;

            string newName = newTenant == null
                ? "NULL"
                : newTenant.Name;

            Debug.WriteLine("Tenant changed from {0} to {1}", oldName, newName);
        }

        public Tenant Tenant
        {
            get { return (Tenant) GetValue(TenantProperty); }
            set { SetValue(TenantProperty, value); }
        }

        public static readonly DependencyProperty IsReadonlyProperty = DependencyProperty.Register(
            "IsReadonly", typeof (bool), typeof (TenantsEditor), new PropertyMetadata(false, OnIsReadonlyChanged));

        private static void OnIsReadonlyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var editor = (TenantsEditor) dependencyObject;
            var newValue = (bool)dependencyPropertyChangedEventArgs.NewValue;
            editor.IsEditable = !newValue;
        }

        public bool IsReadonly
        {
            get { return (bool) GetValue(IsReadonlyProperty); }
            set { SetValue(IsReadonlyProperty, value); }
        }

        public static readonly DependencyProperty IsEditableProperty = DependencyProperty.Register(
            "IsEditable", typeof (bool), typeof (TenantsEditor), new PropertyMetadata(true));

        public bool IsEditable
        {
            get { return (bool) GetValue(IsEditableProperty); }
            private set{ SetValue(IsEditableProperty, value); }
        }
    }
}
