import { getDepotFullInfo } from "@/services/depot_service";
import DepotFullInfo from "./depot_full_info";


export default async function DepotPage({params} : any) {
    const depot = await getDepotFullInfo(params.id);
    return (
        <div>
            <h1 className="text-center text-4xl text-blue-500 m-5">Depot</h1>
            <DepotFullInfo key={depot.id} depot={depot} />
        </div>
    );
}