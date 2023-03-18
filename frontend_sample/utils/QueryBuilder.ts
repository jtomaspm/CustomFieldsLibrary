export default class QueryBuilder {
    private _filter: string;
    private _orderBy: string;
    private _top: number;
    private _skip: number;
    private _query: string;

    public constructor() {
        this._filter = "";
        this._orderBy = "";
        this._top = -1;
        this._skip = -1;
        this._query = "";
    }

    public filter(filter: string): QueryBuilder {
        this._filter = filter;
        return this;
    }

    public orderBy(orderBy: string): QueryBuilder {
        this._orderBy = orderBy;
        return this;
    }

    public top(top: number): QueryBuilder { 
        this._top = top;
        return this;
    }

    public skip(skip: number): QueryBuilder {
        this._skip = skip;
        return this;
    }

    public build(): string {
        if(this._top > 0) this._query += `$top=${this._top}&`;
        if(this._skip > 0) this._query += `$skip=${this._skip}&`;
        if(this._filter.length > 0) this._query += `$filter=${this._filter}&`;
        if(this._orderBy.length > 0) this._query += `$orderBy=${this._orderBy}&`;
        if(this._query.length > 0) this._query = "?" + this._query.slice(0, -1);
        console.log(this._query);
        return this._query;
    }
}
