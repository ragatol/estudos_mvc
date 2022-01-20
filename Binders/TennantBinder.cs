namespace mvc_test.Binders;

using mvc_test.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

//
// O ModelBinder serve para transformar um campo da rota
// no tipo do parâmetro do método do controlador que
// responde àquela rota, quando usamos tipos "complexos",
// aqueles que não sejam string, int, bool, e outros suportados
// nativamente pelo MVC.
//

public class TennantBinder : IModelBinder
{

    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
		// Contexto nulo é um erro...
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

		// No ModelBindingContext temos as informações do campo que foi identificado
		// no request (via GET ou POST). O nome do campo está em ModelName,
		// e podemos pegar seu valor usando o ValueProvider.
        var modelName = bindingContext.ModelName;
        var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

		// O ValueProvider pode estar vazio ou com um valor inválido que devemos
		// conferir.
        if (valueProviderResult == ValueProviderResult.None)
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

		// Associar o valor conferido ao campo que estamos trabalhando no estado
		// do modelo
        bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

		// Agora sim, ler o valor guardado no ValueProviderResult e usá-lo para
		// criar a instância da nossa classe "complexa".
        var val = valueProviderResult.FirstValue;
        if (string.IsNullOrEmpty(val))
        {
            return Task.CompletedTask;
        }

        bindingContext.Result = ModelBindingResult.Success(new Tennant(val));

		// Estamos trabalhando em async com um Task, então sempre retornar o estado
		// de nosso Task...
        return Task.CompletedTask;
    }

}
