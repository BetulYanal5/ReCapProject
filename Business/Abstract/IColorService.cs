using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAllColors();
        IDataResult<Color> GetColorsById(int id);
        IResult Add(Color color);
        IResult Delete(Color color);
        IResult Update(Color color);
    }
}
