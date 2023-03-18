export default function Loading({ page } : {page: string}){
    return (
        <div>
            <h1 className="text-center text-4xl text-blue-500 m-5">Loading {page}...</h1>
        </div>
    );
}