import https from 'https';

export function getAxiosConfigs() {
    const agent = new https.Agent({
            rejectUnauthorized : false
        });
    return {
        httpsAgent: agent,
        next : { revalidate : 2 } 
    };
} 

export function getBackendApiEndpoint() {
    return 'https://localhost:7037/api/'
}

export const DEFAULT_PAGE_SIZE = 6;