using EMS.DTOs;
using EMS.Filter;
using EMS.Response;
using EMS.Service.Journal;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controller;

[ApiController]
[Route("api/journal")]
public class JournalController(IJournalService journalService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetJournals([FromQuery] JournalFilter filter)
        => Ok(ApiResponse<PaginationResponse<IEnumerable<ReadJournal>>>.Success(null,
            journalService.GetAllJournals(filter)));
    [HttpGet("{id:int}")]
    public IActionResult GetJournalById(int id)
    {
        ReadJournal? res = journalService.GetJournalById(id);
        return res != null
            ? Ok(ApiResponse<ReadJournal?>.Success(null, res))
            : NotFound(ApiResponse<ReadJournal?>.Fail(null, null));
    }

    [HttpPost]
    public IActionResult CreateJournal(int employeeId,bool isApsent, DateTime data, int  amountOfLating, string comment)
    {
        CreateJournal journal = new CreateJournal(employeeId, isApsent, data, amountOfLating, comment);
        bool res = journalService.CreateJournal(journal);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : BadRequest(ApiResponse<bool>.Fail(null, res));
    }

    [HttpPut]
    public IActionResult UpdateJournal(UpdateJournal journal)
    {
        bool res = journalService.UpdateJournal(journal);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : NotFound(ApiResponse<bool>.Fail(null, res));
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteJournal(int id)
    {
        bool res = journalService.DeleteJournal(id);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : NotFound(ApiResponse<bool>.Fail(null, res));
    }
}