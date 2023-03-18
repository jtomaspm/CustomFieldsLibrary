import { getDepots } from "@/services/depot_service";
import Depot from "./depot";

export default async function DepotsPage() {
    const depots = await getDepots();
    return(
        <div>
            <h1 className="text-center text-4xl text-blue-500 m-5">Depots</h1>
            <div className="grid grid-cols-2 gap-4 justify-items-center">
                {
                    depots?.map((depot) => {
                        return <Depot key={depot.id} depot={depot}/>;
                    })
                }
            </div>
        </div>
    );
}