export function getTableFormat(date_string : string){
    let dsplit = date_string.split("T");
    if(dsplit.length < 2) return "";
    let date = dsplit[0];
    let time = dsplit[1];


    let d = date.split("-");
    let t = time.split(":");
    if(d.length < 3 || t.length < 2) return "";
    let res = `${d[2]}/${d[1]}/${d[0]} ${t[0]}:${t[1]}`;
    return res;
}