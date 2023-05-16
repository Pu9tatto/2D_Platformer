using UnityEngine;
using UnityEngine.UI;

public class StatWidget : MonoBehaviour, IItemRenderer<StatDef>
{
    [SerializeField] private Image _icon;
    [SerializeField] private ProgressBarWidget _progressBar;
    [SerializeField] private Text _name;
    [SerializeField] private Text _currentValue;
    [SerializeField] private Text _price;
    [SerializeField] private GameObject _priceContainer;

    private GameSession _session;
    private StatsLevelModel _statsMolel;
    private StatDef _data;

    private void Start()
    {
        _session = GameSession.Session;
        _statsMolel = _session.StatsLevelModel;
        UpdateView();
    }


    public void SetData(StatDef data, int index)
    {
        _data = data;
        if (_session != null)
        {
            UpdateView();
        }
    }
    private void UpdateView()
    {
        _icon.sprite = _data.Icon;
        _name.text = LocalizationManager.I.Localize(_data.Name) + ": ";
        _currentValue.text = _statsMolel.GetValue(_data.Id).ToString();
        var currentLevel = _statsMolel.GetLevel(_data.Id);
        var nextLevel = currentLevel + 1;
        var maxLevel = _data.MaxLevel;
        if(nextLevel == maxLevel)
        {
            _priceContainer.SetActive(false);
        }
        else
        {
            _price.text = _data.Levels[nextLevel].Price.ToString();
        }

        _progressBar.SetProgress((float)currentLevel / (maxLevel - 1));
    }

    public void OnBuy()
    {
        _statsMolel.LevelUp(_data.Id);
    }
}
