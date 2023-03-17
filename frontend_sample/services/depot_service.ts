import axios from "axios";
import { getAxiosConfigs, getBackendApiEndpoint } from "./backend_service";



export async function getDepots(){
    const res = await axios.get( getBackendApiEndpoint() + 'Depot', getAxiosConfigs() ).catch((error) => {
        console.log(error);
    });
    return res?.data as any[];
}