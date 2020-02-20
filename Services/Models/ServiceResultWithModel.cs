using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class ServiceResultWithModel<TModel> : ServiceResult
    {
        public TModel Model { get; set; }

        public ServiceResultWithModel() { }

        public ServiceResultWithModel(bool success, TModel model)
        {
            Succeeded = success;
            Errors = new string[0];
            Model = model;
        }

        public new static ServiceResultWithModel<TModel> Success(TModel model)
        {
            return new ServiceResultWithModel<TModel>(true, model);
        }

        public new static ServiceResultWithModel<TModel> Failed(params string[] errors)
        {
            return new ServiceResultWithModel<TModel>()
            {
                Succeeded = false,
                Errors = errors
            };
        }
    }
}
