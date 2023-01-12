using System.Collections.Generic;
using System.Windows.Input;
using WpfDBConn.Commands;
using WpfDBConn.Models;
using WpfDBConn.Repositories;

namespace WpfDBConn.ViewModels
{
  public class MainViewModel : ViewModelBase
  {
    private IAccountRepository _accountRepository;
    private List<Account> _accounts = default!;

    private void Connection(object _)
    {

    }

    private void Insert(object _)
    {
      Account account = new()
      {
        Email = "test123@naver.com",
        Pwd = "abcdefg",
        NickName = "까불이",
        CellPhone = "01099991234",
      };
      _accountRepository.Insert(account);
    }

    private void Update(object _)
    {
      Account account = new()
      {
        Id = 1,
        Email = "abcdEmail@naver.com",
        Pwd = "102030",
        NickName = "어르신",
        CellPhone = "01033335555",
      };
      _accountRepository.Update(account);
    }

    private void Delete(object _)
    {
      _accountRepository.Delete(4);
    }

    private void Select(object _)
    {
      Accounts = _accountRepository.GetAll();
    }

    public MainViewModel(IAccountRepository accountRepository)
    {
      _accountRepository = accountRepository;
    }

    public List<Account> Accounts
    {
      get => _accounts; set
      {
        if (_accounts != value)
        {
          _accounts = value;
          OnPropertyChanged();
        }
      }
    }
    public ICommand ConnectionCommand => new RelayCommand<object>(Connection);
    public ICommand InsertCommand => new RelayCommand<object>(Insert);
    public ICommand UpdateCommand => new RelayCommand<object>(Update);
    public ICommand DeleteCommand => new RelayCommand<object>(Delete);
    public ICommand SelectCommand => new RelayCommand<object>(Select);
  }
}
