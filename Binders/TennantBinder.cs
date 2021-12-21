namespace mvc_test.Binders;

using mvc_test.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

public class TennantBinder : IModelBinder
{

    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var modelName = bindingContext.ModelName;
        var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

        var val = valueProviderResult.FirstValue;
        if (string.IsNullOrEmpty(val))
        {
            return Task.CompletedTask;
        }

        bindingContext.Result = ModelBindingResult.Success(new Tennant(val));
        return Task.CompletedTask;
    }

}
