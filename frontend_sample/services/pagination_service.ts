import QueryBuilder from "@/utils/QueryBuilder";
import axios from "axios";
import { DEFAULT_PAGE_SIZE, getAxiosConfigs, getBackendApiEndpoint } from "./backend_service";

export async function getPaginatedResults<T>(endpoint : string, page : number){
    const queryBuilder = new QueryBuilder();
    const query = queryBuilder.skip(page - 1).top(DEFAULT_PAGE_SIZE).build();
    const res = await axios.get(getBackendApiEndpoint() + endpoint + query, getAxiosConfigs()).catch((error) => {
        console.log(error);
    });
    const result = res?.data as T[];
    return result;
}