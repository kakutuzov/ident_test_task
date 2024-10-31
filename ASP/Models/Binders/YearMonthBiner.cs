using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ExampleApp;

public class YearMonthBiner : IModelBinder
{
    protected const string ParameterName = "YearMonth";

    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var context = bindingContext ?? throw new ArgumentNullException(nameof(bindingContext));
        var values = context.ValueProvider.GetValue(ParameterName);
        if(values == ValueProviderResult.None)
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }
        var splited = values.FirstValue?.Split(".");
        if (splited == null || splited.Length != 2)
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }
        if (!Int32.TryParse(splited[0], out var month))
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }
        if (!Int32.TryParse(splited[1], out var year))
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

        var result = new TestFilter() { 
            YearMonth = new YearMonth() {
                Month = month,
                Year = year
            } 
        };

        bindingContext.Result = ModelBindingResult.Success(result);

        return Task.CompletedTask;
    }
}
