namespace Grille.BeamNgLib.IO.Resources;

internal class GroupResource : Resource
{
    public GroupResource(string name, bool isGameResource, Resource[] resources) : base(name, isGameResource)
    {

    }

    public override Stream Open()
    {
        throw new NotImplementedException();
    }
}
