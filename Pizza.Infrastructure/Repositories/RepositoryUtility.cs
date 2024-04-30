namespace Pizza.Infrastructure.Repositories
{
    public static class RepositoryUtility<T>
    {
        public static void UpdateProperties(T model, T newModel)
        { 
            var properties = newModel.GetType().GetProperties().Where( x => x.GetValue(newModel) != null);
            foreach ( var property in properties)
            {
                var value = property.GetValue(model);
                var newValue = property.GetValue(newModel);

                if (!value.Equals(newValue))
                    property.SetValue(model, newValue);

            }
        }
    }
}
