using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;
internal class ErrorLogger
{
    readonly List<object> _errors = new List<object>();

    public ErrorLogger()
    {
        _errors = new List<object>();
    }

    public int Count => _errors.Count;

    public void Add(object message)
    {
        _errors.Add(message);
    }

    public void Clear()
    {
        _errors.Clear();
    }

    public void Print()
    {
        if (_errors.Count == 0)
            return;

        Logger.WriteLine($"{_errors.Count} errors while loading assets.", LoggerColor.Red);

        Logger.WriteLine();

        for (int i = 0; i < _errors.Count; i++)
        {
            var error = _errors[i];

            var message = error.ToString();

            if (message == null)
                throw new Exception();

            Logger.WriteLine(message);
            Logger.WriteLine();
        }
    }
}
