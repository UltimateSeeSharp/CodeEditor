using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Placeholder;

public class ViewModelBase : INotifyPropertyChanged
{
    /// Standard implementation of <seealso cref="INotifyPropertyChanged"/>.
    public event PropertyChangedEventHandler PropertyChanged;

    /// Tell bound controls (via WPF binding) to refresh their display.
    /// Sample call: this.NotifyPropertyChanged(() => this.IsSelected);
    /// where 'this' is derived from <seealso cref="ViewModelBase"/>
    /// and IsSelected is a property.
    public void RaisePropertyChanged<TProperty>(Expression<Func<TProperty>> property)
    {
        var lambda = (LambdaExpression)property;
        MemberExpression memberExpression;

        if (lambda.Body is UnaryExpression)
        {
            var unaryExpression = (UnaryExpression)lambda.Body;
            memberExpression = (MemberExpression)unaryExpression.Operand;
        }
        else
            memberExpression = (MemberExpression)lambda.Body;

        this.RaisePropertyChanged(memberExpression.Member.Name);
    }

    /// Tell bound controls (via WPF binding) to refresh their display.
    /// Standard implementation through <seealso cref="INotifyPropertyChanged"/>.
    protected virtual void RaisePropertyChanged(string propertyName)
    {
        if (this.PropertyChanged != null)
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}
