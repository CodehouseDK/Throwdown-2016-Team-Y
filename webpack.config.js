var path = require("path");
var webpack = require("webpack");
var ExtractTextPlugin = require("extract-text-webpack-plugin");

module.exports = {
    target: 'node',
    context: __dirname,
    entry: {
        bundle: path.resolve(__dirname, "wwwroot/scripts/app.ts")
    },
    output: {
        path: path.resolve(__dirname, "wwwroot/build/js"),
        filename: "bundle.js"
    },
    // Turn on sourcemaps
    devtool: 'source-map',
    resolve: {
        // Add `.ts` and `.tsx` as a resolvable extension.
        extensions: ['', '.webpack.js', '.web.js', '.ts', '.tsx', '.js']
    },
    module: {
        loaders: [
            { test: /\.tsx?$/, loader: 'ts-loader', exclude: "/node_modules/" },
            { test: /\.(scss|sass|css)$/, loader: ExtractTextPlugin.extract("style", "css!sass") }
        ]
    },
    plugins: [
        new webpack.optimize.UglifyJsPlugin({
            compress: {
                warnings: false
            }
        }),
        new ExtractTextPlugin("../../../wwwroot/build/style/bundle.css")
    ]
}
