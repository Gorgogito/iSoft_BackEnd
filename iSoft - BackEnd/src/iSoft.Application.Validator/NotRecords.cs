﻿using iSoft.Cross.Common;

namespace iSoft.Application.Validator
{
  public class NotRecords<T>
  {

    Response<T> _response = new Response<T>();
    T _record;
    bool _success;

    public NotRecords(T dto)
    {
      _record = dto;
      if (dto == null)
      {
        _response.Message = "No existen registros.";

        ErrorResponse err = new ErrorResponse()
        {
          PropertyName = "Not Records",
          ErrorMessage = "No se han encontrado registros.",
          AttemptedValue = "",
          CustomState = null,
          Severity = 0,
          ErrorCode = "EmptyResult",
        };
        List<FluentValidation.Results.ValidationFailure> errs = [err];
        _response.Errors = errs;
        _success = false;
      }
      else
      { _success = true; }
    }

    public bool Success { get { return _success; } }

    public Response<T> Response { get { return _response; } }

    public T Record { get { return _record; } }

  }
}