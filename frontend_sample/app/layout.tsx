
export const dynamic = 'auto',
    dynamicParams = true,
    revalidate = 0,
    fetchCache = 'auto',
    runtime = 'nodejs',
    preferedRegion = 'auto';



import { Catamaran } from '@next/font/google'
import './global.css'

const main_font = Catamaran({
    variable : "--main-font",
})

export default function RootLayout({
    children,
}: {
    children: React.ReactNode;
}) {
    const normal_btn = "btn btn-outline btn-accent normal-case text-xl mx-1"
    const active_btn = "btn btn-outline btn-accent normal-case text-xl mx-1"
    return (
        <html data-theme="dark">
            <head></head>
            <body>
                <main>
                    <div className="navbar bg-base-100  text-purple-300 flex justify-center">
                        <a href="/" className={normal_btn}>Dashboard</a>
                        <a href="/depots" className={normal_btn}>Depots</a>
                        <a href="/containers" className={normal_btn}>Containers</a>
                    </div>
                    <div className="flex justify-center">
                        {children}
                    </div>
                </main>
            </body>
        </html>
    );
}
