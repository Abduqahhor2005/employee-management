using EMS.DTOs;
using EMS.Filter;
using EMS.Mapper;
using EMS.Response;

namespace EMS.Service.Journal;

public class JournalService(DataContext context) : IJournalService
{
    public PaginationResponse<IEnumerable<ReadJournal>> GetAllJournals(JournalFilter filter)
    {
        IQueryable<Entities.Journal> journals = context.Journals;
        if (filter.EmployeeId != null)
            journals = journals.Where(x => x.EmployeeId == filter.EmployeeId);
        if (filter.IsApsent != null)
            journals = journals.Where(x => x.IsApsent == filter.IsApsent);
        IQueryable<ReadJournal> res = journals.Where(x=>x.IsDeleted==false).Skip((filter.PageNumber - 1) * filter.PageSize).
            Take(filter.PageSize).Select(x=>x.ReadToJournal());
        int totalRecords = context.Journals.Count();
        return PaginationResponse<IEnumerable<ReadJournal>>.Create(filter.PageSize, filter.PageNumber, totalRecords,
            res);
    }

    public ReadJournal? GetJournalById(int id)
    {
        ReadJournal readJournal = context.Journals.Where(x => x.Id == id && x.IsDeleted==false).
            Select(x=>x.ReadToJournal()).FirstOrDefault();
        return readJournal;
    }

    public bool CreateJournal(CreateJournal createJournal)
    {
        if (createJournal==null) return false;
        context.Journals.Add(createJournal.CreateToJournal());
        context.SaveChanges();
        return true;
    }

    public bool UpdateJournal(UpdateJournal updateJournal)
    {
        Entities.Journal journal = context.Journals.FirstOrDefault(x => x.Id == updateJournal.Id && x.IsDeleted==false)!;
        if (journal==null) return false;
        context.Journals.Update(journal.UpdateToJournal(updateJournal));
        context.SaveChanges();
        return true;
    }

    public bool DeleteJournal(int id)
    {
        Entities.Journal? journal = context.Journals.FirstOrDefault(x => x.Id == id);
        if (journal is null) return false;
        journal.DeleteToJournal();
        context.SaveChanges();
        return true;
    }
}