import { getContainerFullDetails } from "@/services/container_service";
import { getTableFormat } from "@/utils/date_formater";

export default async function ContainerFullDetails({params} : any) {
    const th_class = "text-1xl";
    const container = await getContainerFullDetails(params.id);
    return(
        <div>
            <h1 className="text-center text-4xl text-blue-500 m-5">Container</h1>
            <div>
                <div className="text-right">
                    <h2 className="text-sm">{container.code}</h2>
                    <h2 className="text-sm">{container.containerType}</h2>
                    <h2 className="text-sm">{container.owner}</h2>
                </div>
                <h2 className="text-2xl my-5">Operations:</h2>
                <div className="overflow-x-auto">
                    <table className="table table-compact p-0">
                        <thead>
                            <tr >
                                <th><h1 className={th_class}>Type</h1></th>
                                <th><h1 className={th_class}>Depot</h1></th>
                                <th><h1 className={th_class}>Client</h1></th>
                                <th><h1 className={th_class}>Supplier</h1></th>
                                <th><h1 className={th_class}>Date</h1></th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                container.operations.map((operation) => {
                                    const tr_class = "hover:bg-cyan-900"
                                    return (
                                        <tr className={tr_class} key={operation.id} >
                                            <td>{operation.operationType}</td>
                                            <td>{operation.depot}</td>
                                            <td>{operation.client}</td>
                                            <td>{operation.supplier}</td>
                                            <td>{operation.date}</td>
                                        </tr>
                                    );
                                })}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
}

