using System;
using Xamarin.Forms;


namespace CustomThings.Controls
{
    public partial class FormEntry : StackLayout
    {
        #region Properties

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(FormEntry), default(string), propertyChanged: OnPlaceholderChanged);
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        static void OnPlaceholderChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (FormEntry)bindable;
            var value = (string)newValue;

            control.entry.Placeholder = value;
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(FormEntry), default(string), propertyChanged: OnTitleChanged);
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        static void OnTitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (FormEntry)bindable;
            var value = (string)newValue;

            control.titleLabel.Text = value;
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(FormEntry), default(string), propertyChanged: OnTextChanged);
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (FormEntry)bindable;
            var value = (string)newValue;

            control.entry.Text = value;
        }

        public static readonly BindableProperty ActiveColorProperty = BindableProperty.Create(nameof(ActiveColor), typeof(Color), typeof(FormEntry), default(Color), propertyChanged: OnActiveColorChanged);
        public Color ActiveColor
        {
            get => (Color)GetValue(ActiveColorProperty);
            set => SetValue(ActiveColorProperty, value);
        }

        static void OnActiveColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (FormEntry)bindable;
            var value = (Color)newValue;
            if (control.entry.IsFocused)
            {
                control.line.BackgroundColor = value;
            }
        }

        public static readonly BindableProperty InactiveColourProperty = BindableProperty.Create(nameof(InactiveColour), typeof(Color), typeof(FormEntry), default(Color), propertyChanged: OnInactiveColourChanged);
        public Color InactiveColour
        {
            get => (Color)GetValue(InactiveColourProperty);
            set => SetValue(InactiveColourProperty, value);
        }

        static void OnInactiveColourChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (FormEntry)bindable;
            var value = (Color)newValue;

            if (!control.entry.IsFocused)
            {
                control.line.BackgroundColor = value;
            }
        }

        #endregion Properties

        #region Constructor

        public FormEntry()
        {
            InitializeComponent();

            entry.Focused += Entry_Focused;
            entry.Unfocused += Entry_Focused;
        }


        #endregion Constructor

        #region Methods

        #endregion Methods

        void Entry_Focused(object sender, FocusEventArgs e)
        {
            line.BackgroundColor = e.IsFocused ? ActiveColor : InactiveColour;
        }

    }
}