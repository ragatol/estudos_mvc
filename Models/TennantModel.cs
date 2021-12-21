namespace mvc_test.Models;

using Microsoft.AspNetCore.Mvc;
using mvc_test.Binders;

[ModelBinder(BinderType = typeof(TennantBinder))]
public  class Tennant
{
    
    public string ID;

    public Tennant(string id)
    {
        this.ID = id;
    }

}
