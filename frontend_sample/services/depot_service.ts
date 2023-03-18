import { getTableFormat } from "@/utils/date_formater";
import axios from "axios";
import { getAxiosConfigs, getBackendApiEndpoint } from "./backend_service";
import { ContainerInDepot } from "./container_service";

export type Depot = {
    id: number,
    name: string,
    location: string,
    owener: string
}

export type Operation = {
    id: number,
    container: string,
    operationType: string,
    depot: string,
    date: string,
    client: string,
    supplier: string
}

export type DepotExtraInfo = {
    containers: ContainerInDepot[]
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
    let result = res?.data as DepotFullInfo | undefined;
    if (result && result.containers)
        result.containers = result.containers.map((container) => {
            return {
                code: container.code,
                containerType: container.containerType,
                depot: container.depot,
                id: container.id,
                owner: container.owner,
                inDate: getTableFormat(container.inDate)
            } as ContainerInDepot
        });
    return result as DepotFullInfo;
}