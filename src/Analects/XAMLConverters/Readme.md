Analects.Loader is a collection of XAML converters.

The base class MarkupConverter provides a standard implementation for converters.

DebugConverter prints debug messages during runtime.

BoolToVisibility converts booleans to visibility, but also allows you to invert the visibility.

NullToVisibility converts an object reference to visibility. Useful for hiding stuff when a value is not set.

ToUpper and ToLower convert a string to its upper or lower version. This can be used in metro styles where the case is important.

The base class allows you to define converters in XAML without having to define them as a static resource first.

    <TextBlock Text="Foo" Visibility="{Binding IsFoo, {analects:BoolToVisibility}}" />

And to invert the boolean.

    <TextBlock Text="Foo" Visibility="{Binding IsFoo, {analects:BoolToVisibility Invert=true}}" />