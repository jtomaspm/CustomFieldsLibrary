import axios from "axios";
import { getAxiosConfigs, getBackendApiEndpoint } from "./backend_service";

export type Container = {
    id : number,
    code : string,
    containerType : string,
    owner : string,
    depot : string,
}

export type ContainerInDepot = Container & { inDate : string }

export async function getContainers() {
    const res = await axios.get(getBackendApiEndpoint() + 'Container', getAxiosConfigs()).catch((error) => {
        console.log(error);
    });
    console.log(res);
    return res?.data as Container[];
}

