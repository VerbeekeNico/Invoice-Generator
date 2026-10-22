# Stage 1: Build the Angular application
FROM node:22-alpine AS build

WORKDIR /app

# Copy dependency files first for Docker layer caching
COPY package*.json ./

RUN npm ci

# Copy the rest of the application
COPY . .

# Build the Angular application
RUN npm run build


# Stage 2: Serve the application with Nginx
FROM nginx:alpine

# Copy the built Angular application to Nginx
COPY --from=build /app/dist/inv-gen-angular-client/browser /usr/share/nginx/html
# Copy runtime configuration template
COPY --from=build /app/public/config.template.json /usr/share/nginx/html/config.template.json
# Copy the startup script
COPY docker-entrypoint.sh /docker-entrypoint.sh

# Make the script executable
RUN chmod +x /docker-entrypoint.sh

# Run the startup script when the container starts
ENTRYPOINT ["/docker-entrypoint.sh"]

# Expose port 80
EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]