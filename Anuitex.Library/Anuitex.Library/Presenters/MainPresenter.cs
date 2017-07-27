using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anuitex.Library.Base.Enums;
using Anuitex.Library.Data;
using Anuitex.Library.Data.Entities;
using Anuitex.Library.Data.Interfaces;
using Anuitex.Library.Models;
using Anuitex.Library.Models.Providers;
using Anuitex.Library.Models.Repositories;

namespace Anuitex.Library.Presenters
{
    public class MainPresenter
    {
        private readonly MainForm view;
        private readonly BookRepository bookRepository;
        private readonly JournalRepository journalRepository;
        private readonly NewspaperRepository newspaperRepository;

        private readonly XmlRepository xmlRepository;
        private readonly RawFileRepository rawFileRepository;

        public MainPresenter(MainForm view, BookRepository bookRepository, JournalRepository journalRepository, NewspaperRepository newspaperRepository, XmlRepository xmlRepository, RawFileRepository rawFileRepository)
        {
            this.view = view;
            this.bookRepository = bookRepository;
            this.journalRepository = journalRepository;
            this.newspaperRepository = newspaperRepository;
            this.xmlRepository = xmlRepository;
            this.rawFileRepository = rawFileRepository;

            this.view.DataUpdated += OnViewDataUpdated;
            this.view.DeletedEntity += OnViewDeletedEntity;
            this.view.CreatedEntity += OnViewCreatedEntity;
            this.view.UpdatedEntity += OnViewUpdatedEntity;
            this.view.SelledEntity += OnViewSelledEntity;

            this.view.Exported += OnViewExported;            
            this.view.Imported += OnViewImported;                  
        }

        private void OnViewImported(Type type, string path, FileStorageType storageType)
        {
            if (type == typeof(Book))
            {
                if (storageType == FileStorageType.Raw)
                {
                    view.Books = rawFileRepository.Import<Book>(path);
                }
                if (storageType == FileStorageType.Xml)
                {
                    view.Books = xmlRepository.Import<Book>(path);
                }
            }
            if (type == typeof(Journal))
            {
                if (storageType == FileStorageType.Raw)
                {
                    view.Journals = rawFileRepository.Import<Journal>(path);
                }
                if (storageType == FileStorageType.Xml)
                {
                    view.Journals = xmlRepository.Import<Journal>(path);
                }                
            }
            if (type == typeof(Newspaper))
            {
                if (storageType == FileStorageType.Raw)
                {
                    view.Newspapers = rawFileRepository.Import<Newspaper>(path);
                }
                if (storageType == FileStorageType.Xml)
                {
                    view.Newspapers = xmlRepository.Import<Newspaper>(path);
                }
            }
        }

        private void OnViewExported(List<ILibraryEntity> entities, string path, FileStorageType storageType)
        {
            if (storageType == FileStorageType.Raw)
            {
                rawFileRepository.Export(entities,path);
            }
            if (storageType == FileStorageType.Xml)
            {
                xmlRepository.Export(entities, path);
            }
        }



        private void OnViewSelledEntity(ILibraryEntity entity)
        {
            entity.Amount--;
            if (entity is Book)
            {                
                bookRepository.Update(entity as Book);
            }
            if (entity is Journal)
            {
                journalRepository.Update(entity as Journal);
            }
            if (entity is Newspaper)
            {
                newspaperRepository.Update(entity as Newspaper);
            }
        }

        private void OnViewUpdatedEntity(ILibraryEntity entity)
        {
            if (entity is Book)
            {
                bookRepository.Update(entity as Book);
            }
            if (entity is Journal)
            {
                journalRepository.Update(entity as Journal);
            }
            if (entity is Newspaper)
            {
                newspaperRepository.Update(entity as Newspaper);
            }
        }

        private void OnViewCreatedEntity(ILibraryEntity entity)
        {
            if (entity is Book)
            {
                bookRepository.Add(entity as Book);
            }
            if (entity is Journal)
            {
                journalRepository.Add(entity as Journal);
            }
            if (entity is Newspaper)
            {
                newspaperRepository.Add(entity as Newspaper);
            }
        }

        private void OnViewDeletedEntity(ILibraryEntity entity)
        {
            if (entity is Book)
            {
                bookRepository.Delete(entity as Book);
            }
            if (entity is Journal)
            {
                journalRepository.Delete(entity as Journal);
            }
            if (entity is Newspaper)
            {
                newspaperRepository.Delete(entity as Newspaper);
            }
        }

        private void OnViewDataUpdated(Type type)
        {
            if (type == typeof(Book))
            {
                view.Books = bookRepository.GetList();
            }
            if (type == typeof(Journal))
            {
                view.Journals = journalRepository.GetList();
            }
            if (type == typeof(Newspaper))
            {
                view.Newspapers = newspaperRepository.GetList();
            }
        }

        public void Run()
        {
            view.Show();            
        }
    }
}
