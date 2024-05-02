﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Publisher.Controllers.V1_0.Common;
using Publisher.Entity.Db;
using Publisher.Entity.DTO.RequestTO;
using Publisher.Entity.DTO.ResponseTO;
using Publisher.Service.Interface;
using System.Text;

namespace Publisher.Controllers.V1_0
{
    [Route("api/v1.0/notes")]
    [ApiController]
    public class NoteController(INoteService NoteService, ILogger<NoteController> Logger, IMapper Mapper)
        : AbstractController<Note, NoteRequestTO, NoteResponseTO>(NoteService, Logger, Mapper)
    {
        public override async Task<JsonResult> GetByID([FromRoute] int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"http://discussion:24130/api/v1.0/notes/{id}");

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject(jsonResponse);

            return new JsonResult(jsonObject)
            {
                StatusCode = (int)response.StatusCode
            };
        }

        public override async Task<IActionResult> Read()
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"http://discussion:24130/api/v1.0/notes");

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject(jsonResponse);

            return new JsonResult(jsonObject)
            {
                StatusCode = (int)response.StatusCode
            };
        }

        public override async Task<JsonResult> Create([FromBody] NoteRequestTO request)
        {
            var client = new HttpClient();
            var jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://discussion:24130/api/v1.0/notes", content);

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject(jsonResponse);

            return new JsonResult(jsonObject)
            {
                StatusCode = (int)response.StatusCode
            };
        }

        public override async Task<JsonResult> Update([FromBody] NoteRequestTO request)
        {
            var client = new HttpClient();
            var jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://discussion:24130/api/v1.0/notes", content);

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject(jsonResponse);

            return new JsonResult(jsonObject)
            {
                StatusCode = (int)response.StatusCode
            };
        }

        public override async Task<IActionResult> Delete([FromRoute] int id)
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync($"http://discussion:24130/api/v1.0/notes/{id}");

            return StatusCode((int)response.StatusCode);
        }
    }
}
