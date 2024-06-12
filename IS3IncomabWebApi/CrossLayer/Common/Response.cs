﻿using Microsoft.IdentityModel.Tokens;

namespace IS3IncomabWebApi.CrossLayer.Common
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public bool IsSucces {  get; set; }
        public string? Message { get; set; }
        public IEnumerable<ValidationFailure>? Error { get; set; }
    }
}
