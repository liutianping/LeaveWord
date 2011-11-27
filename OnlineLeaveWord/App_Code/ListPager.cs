using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

/// <summary>
/// ListPager 的摘要说明
/// </summary>
public class ListPager<T> : System.Collections.Generic.List<T>
{
    public ListPager()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    private int _CurrentIndex;
    private int _PageSize;
    private int _TotalItem;
    private int _PageCount;

    /// <summary>
    /// 当前页码
    /// </summary>
    public int CurrentIndex
    {
        get { return _CurrentIndex; }
        set { _CurrentIndex = value; }
    }

    /// <summary>
    /// 每页大小
    /// </summary>
    public int PageSize
    {
        get { return _PageSize; }
        set { _PageSize = value; }
    }

    /// <summary>
    /// 记录总数
    /// </summary>
    public int TotalItem
    {
        get { return _TotalItem; }
        set { _TotalItem = value; }
    }

    /// <summary>
    /// 页面总数
    /// </summary>
    public int PageCount
    {
        get { return _PageCount; }
        set { _PageCount = value; }
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="list">要分页的List泛型</param>
    /// <param name="index">起始页码</param>
    /// <param name="pageSize">分页大小</param>
    public ListPager(List<T> list, int index, int pageSize)
    {
        this._CurrentIndex = index;
        this._PageSize = pageSize;

        int startIndex = (this._CurrentIndex - 1) * PageSize;
        for (int i = startIndex; i < startIndex + this._PageSize && i < list.Count; i++)
        {
            this.Add(list[i]);
        }

        this._TotalItem = list.Count;
        //this._PageCount = (this._TotalItem / PageSize) + 1;
        this.PageCount = (this._TotalItem + this.PageSize - 1) / this._PageSize;
    }
}
