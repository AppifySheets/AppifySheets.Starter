using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.BaseImpl.EF;

namespace AppifySheets.Desktop.Launcher.Controllers;

public class EFDetailViewController : ViewController<DetailView>
{
    void ObjectSpace_ObjectChanged(Object? sender, ObjectChangedEventArgs e)
    {
        if (
            e.MemberInfo is { IsPersistent: false } && (
                (e.MemberInfo.MemberType.IsEnum && e.MemberInfo.Owner.IsPersistent)
                ||
                typeof(Image).IsAssignableFrom(e.MemberInfo.MemberType)
                ||
                typeof(Color).IsAssignableFrom(e.MemberInfo.MemberType)
            )
        )
        {
            ObjectSpace.SetModified(null);
        }
    }

    void ObjectSpace_Committed(Object? sender, EventArgs e)
    {
        if (View.CurrentObject is not Event) return;
        var linkToListViewController = Frame.GetController<LinkToListViewController>();
        if (linkToListViewController is { Link.ListView.IsRoot: true })
        {
            linkToListViewController.Link.ListView.ObjectSpace.Refresh();
        }
    }

    protected override void OnActivated()
    {
        base.OnActivated();
        ObjectSpace.ObjectChanged += new EventHandler<ObjectChangedEventArgs>(ObjectSpace_ObjectChanged);
        ObjectSpace.Committed += new EventHandler(ObjectSpace_Committed);
    }

    protected override void OnDeactivated()
    {
        base.OnDeactivated();
        ObjectSpace.ObjectChanged -= new EventHandler<ObjectChangedEventArgs>(ObjectSpace_ObjectChanged);
        ObjectSpace.Committed -= new EventHandler(ObjectSpace_Committed);
    }
}