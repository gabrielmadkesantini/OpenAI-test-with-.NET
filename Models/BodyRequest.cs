
using CsvHelper.Configuration.Attributes;
using Microsoft.AspNetCore.Identity;

namespace test.openAI.api.Models;

public class BodyRequest {
  public string userProposal { get; set; }
}