import axios from "axios";
import { getAxiosConfigs, getBackendApiEndpoint } from "./backend_service";
import { ContainerInDepot } from "./container_service";

export type Depot = {
    id: number,
    name: string,
    location: string,
    owener: string
}

export type DepotExtraInfo = {
    containers : ContainerInDepot[]
}

export type DepotFullInfo = Depot & DepotExtraInfo;

export async function getDepots() {
    const res = await axios.get(getBackendApiEndpoint() + 'Depot', getAxiosConfigs()).catch((error) => {
        console.log(error);
    });
    return res?.data as Depot[];
}


export async function getDepotFullInfo(depotId: number) {
    const res = await axios.get(getBackendApiEndpoint() + 'Depot/' + depotId, getAxiosConfigs()).catch((error) => {
        console.log(error);
    });
    return res?.data as DepotFullInfo;
}