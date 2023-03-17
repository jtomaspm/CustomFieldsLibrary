import { getDepots } from "@/services/depot_service";
import Depot from "./depot";

export default async function DepotsPage() {
    const depots = await getDepots();
    return(
        <div>
            <h1>Depots</h1>
            <div>
                {
                    depots?.map((depot) => {
                        return <Depot key={depot.Id} depot={depot}/>;
                    })
                }
            </div>
        </div>
    );
}