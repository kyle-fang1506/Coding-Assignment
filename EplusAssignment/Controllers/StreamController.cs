//using EplusAssignment.Models;
using EplusInputConverter;
using EplusService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EplusAssignment.Controllers
{
    public class StreamController : ApiController
    {

        IConverter converter;
        ICalculationService service;
        public StreamController(IConverter converter, ICalculationService service)
        {
            //I use DI here so that the Ninject will provide a converter and a score calculation service
            this.converter = converter;
            this.service = service;
        }


        public HttpResponseMessage GetScore(string input)
        {
            
            service.Input =(char?[]) converter.Convert(input);
            int score= service.ScoreCalculate();
            if (score==-1) return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid stream, please check!");
            return Request.CreateResponse(HttpStatusCode.OK, score);
        }
    }
}
