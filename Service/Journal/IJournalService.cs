using EMS.DTOs;
using EMS.Filter;
using EMS.Response;

namespace EMS.Service.Journal;

public interface IJournalService
{
    PaginationResponse<IEnumerable<ReadJournal>> GetAllJournals(JournalFilter filter);
    ReadJournal? GetJournalById(int id);
    bool CreateJournal(CreateJournal journal);
    bool UpdateJournal(UpdateJournal journal);
    bool DeleteJournal(int id);
}