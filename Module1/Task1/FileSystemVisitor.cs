using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Entities;

namespace Task1
{
    public class FileSystemVisitor
    {
        public IList<Entity> Heap { get; }
        public string StartFolder { get; set; }
        public Behavior Action { get; set; }

        private readonly Func<string, bool> _compareAlgorithm;
        private readonly Func<string, bool> _action;
        private readonly IFileProvider _fileProvider;

        #region Events Generation Section

        #region FileFinded

        private EventHandler<string> _fileFinded;
        public event EventHandler<string> FileFinded
        {
            add
            {
                _fileFinded += value;
            }
            remove
            {
                _fileFinded -= value;
            }
        }
        private void OnFileFinded(string fileLink)
        {
            var fileFinded = _fileFinded;
            fileFinded?.Invoke(this, $"Find file : {fileLink}");
        }

        #endregion

        #region FolderFinded

        private EventHandler<string> _folderFinded;
        public event EventHandler<string> FolderFinded
        {
            add
            {
                _folderFinded += value;
            }
            remove
            {
                _folderFinded -= value;
            }
        }
        private void OnFolderFinded(string folderLink)
        {
            var folderFinded = _folderFinded;
            folderFinded?.Invoke(this, $"Find folder : {folderLink}");
        }

        #endregion

        #region FilteredFolderFinded

        private EventHandler<string> _filtredFolderFinded;
        public event EventHandler<string> FiltredFolderFinded
        {
            add
            {
                _filtredFolderFinded += value;
            }
            remove
            {
                _filtredFolderFinded -= value;
            }
        }
        private void OnFiltredFolderFinded(string folderLink)
        {
            var filtredFolderFinded = _filtredFolderFinded;
            filtredFolderFinded?.Invoke(this, $"Find filtred folder : {folderLink}");
        }

        #endregion

        #region FiltredFileFinded

        private EventHandler<string> _filtredFileFinded;
        public event EventHandler<string> FiltredFileFinded
        {
            add
            {
                _filtredFileFinded += value;
            }
            remove
            {
                _filtredFileFinded -= value;
            }
        }
        private void OnFiltredFileFinded(string fileLink)
        {
            var filtredFileFinded = _filtredFileFinded;
            filtredFileFinded?.Invoke(this, $"Find filtred file : {fileLink}");
        }

        #endregion

        #region Start

        private EventHandler _start;
        public event EventHandler Start
        {
            add
            {
                _start += value;
            }
            remove
            {
                _start -= value;
            }
        }
        private void OnStart()
        {
            var start = _start;
            start?.Invoke(this, null);
        }

        #endregion

        #region Finish

        private EventHandler _finish;
        public event EventHandler Finish
        {
            add
            {
                _finish += value;
            }
            remove
            {
                _finish -= value;
            }
        }
        private void OnFinish()
        {
            var finish = _finish;
            finish?.Invoke(this, null);
        }

        #endregion

        #endregion
        #region Constructors
        //public FileSystemVisitor(string startFolder, string filter)
        //{

        //}

        public FileSystemVisitor(string startFolder, Func<string, bool> compareAlgorithm, IFileProvider fileProvider)
        {
            StartFolder = startFolder;
            Heap = new List<Entity>();
            _compareAlgorithm = compareAlgorithm;
            _fileProvider = fileProvider;
        }
        #endregion

        public void Initialize()
        {
            OnStart();
            GetFolderEntities(StartFolder);
            OnFinish();
        }

        private void GetFolderEntities(string folderLink)
        {
            var folderLinks = _fileProvider.GetDir(folderLink);

            foreach (var link in folderLinks)
            {
                InsertToHeap(EntityType.folder, link);
                GetFolderEntities(link);
            }

            var fileLinks = _fileProvider.GetFiles(folderLink);
            foreach (var link in fileLinks)
            {
                InsertToHeap(EntityType.file, link);
            }

        }

        private void InsertToHeap(EntityType type, string link)
        {
            var entity = new Entity(link, type);
            if (entity.Type == EntityType.file)
            {
                //Todo: Generate event
                OnFileFinded(link);
            }
            else
            {
                OnFolderFinded(link);
            }
            if (_compareAlgorithm(link))
            {
                Heap.Add(entity);
            }
        }
    }

    [Flags]
    public enum Behavior
    {
        stopSearching,
        skipEntity
    }
}
