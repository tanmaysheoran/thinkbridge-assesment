using Management.Contracts.Interface;
using Management.DBContext;
using Management.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Management.Services
{

    public class TaskNoteService : ITaskNoteSerivce
    {
        private readonly ApplicationDbContext _context;

        public TaskNoteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaskNote> GetTaskNoteAsync(int id)
        {
            return await _context.TaskNotes.Include(tn => tn.RequiredAction).FirstOrDefaultAsync(tn => tn.NoteId == id);
        }

        public async Task<TaskNote> GetTaskNoteByActionIdAsync(int actionId)
        {
            return await _context.TaskNotes
                .Include(tn => tn.RequiredAction)
                .FirstOrDefaultAsync(tn => tn.ActionId == actionId);
        }

        public async Task<TaskNote> CreateTaskNoteAsync(TaskNote note)
        {
            note.CreatedAt = DateTime.UtcNow;
            _context.TaskNotes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<TaskNote> UpdateTaskNoteAsync(TaskNote note)
        {
            var existingNote = await _context.TaskNotes.FindAsync(note.NoteId);
            if (existingNote == null)
            {
                return null;
            }

            existingNote.NoteText = note.NoteText;
            existingNote.ActionId = note.ActionId;
            existingNote.RequiredAction = note.RequiredAction;

            _context.TaskNotes.Update(existingNote);
            await _context.SaveChangesAsync();
            return existingNote;
        }

        public async Task<TaskNote> DeleteTaskNoteAsync(int id)
        {
            var note = await _context.TaskNotes.FindAsync(id);
            if (note == null)
            {
                return null;
            }

            _context.TaskNotes.Remove(note);
            await _context.SaveChangesAsync();
            return note;
        }
    }
}
