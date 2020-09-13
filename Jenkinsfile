#!groovy
pipeline {
    agent {
        docker {
            image 'nosinovacao/dotnet-sonar:20.07.0'
        }
    }
    environment {
        HOME = '/tmp'
    } 
    stages {
        stage('Preparation') {
            steps {
                checkout scm
            }
        }
        stage('Build') {
            steps {
                sh """
                #!/bin/bash
                dotnet build FirstSolution.sln
                """
            }
        }
        stage('Test') {
            steps {
                sh """
                #!/bin/bash
                dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
                """
            }
        }
        stage('SonarQube') {
            steps {
                withSonarQubeEnv('sonarqube') {
                    sh """
                    #!/bin/bash
                    dotnet build-server shutdown
                    dotnet /sonar-scanner/SonarScanner.MSBuild.dll begin /k:"FirstCoreProject" /d:sonar.host.url=http://172.18.0.4:9000 /d:sonar.login="e48ea67ef56e7fe28b84c6d72abe4ff3f43538c5" /d:sonar.cs.opencover.reportsPaths="FirstCoreProject/coverage.opencover.xml" /d:sonar.coverage.exclusions="**Test*.cs"
                    dotnet build FirstSolution.sln
                    dotnet /sonar-scanner/SonarScanner.MSBuild.dll end /d:sonar.login="e48ea67ef56e7fe28b84c6d72abe4ff3f43538c5"
                    """
                }
            }
        }
        stage("Quality Gate") {
            steps {
              timeout(time: 5, unit: 'MINUTES') {
                waitForQualityGate abortPipeline: true
              }
            }
        }
        stage('Run') {
            steps {
                sh """
                #!/bin/bash
                cd FirstCoreProject
                dotnet run
                """
            }
        }
    }
    post {  
        always {  
            echo 'Build Result:'  
        }  
        success {  
            echo 'The .net build was successful !'  
        }  
        failure {  
            echo 'The .net build failed !'
            mail bcc: '', body: "<b>Example</b><br>Project: ${env.JOB_NAME} <br>Build Number: ${env.BUILD_NUMBER} <br> URL de build: ${env.BUILD_URL}", cc: '', charset: 'UTF-8', from: '', mimeType: 'text/html', replyTo: '', subject: "ERROR CI: Project name - ${env.JOB_NAME}", to: "bhachawl2298@gmail.com";  
        }    
    }
}