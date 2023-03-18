import { Depot as DepotType, DepotFullInfo } from "@/services/depot_service";
import Depot from "../depot";

export default function DepotFullInfo({depot}: {depot:DepotFullInfo}) {
    const th_class = "text-1xl";
    return (
        <div>
            <div className="grid justify-items-center">
                <Depot key={depot.id} depot={depot as DepotType} />
            </div>
            <h2 className="text-2xl my-5">Containers:</h2>
            <div className="overflow-x-auto">
                <table className="table table-compact w-200">
                    <tr >
                        <th><h1 className={th_class}>Code</h1></th>
                        <th><h1 className={th_class}>Type</h1></th>
                        <th><h1 className={th_class}>Owener</h1></th>
                        <th><h1 className={th_class}>Date In</h1></th>
                        <th></th>
                    </tr>
                    {
                        depot.containers.map((container) => {
                            const tr_class = "hover:bg-cyan-900"
                            return (
                                <tr className={tr_class} key={container.id} >
                                    <td>{container.code}</td>
                                    <td>{container.containerType}</td>
                                    <td>{container.owener}</td>
                                    <td>{container.inDate}</td>
                                    <td>
                                        <button className="rounded-full btn btn-outline btn-error btn-xs mx-1">Out</button>
                                        <button className="rounded-full btn btn-outline btn-accent btn-xs mx-1">Info</button>
                                    </td>
                                </tr>
                            );
                        })
                    }
                </table>
            </div>
        </div>
    );
}